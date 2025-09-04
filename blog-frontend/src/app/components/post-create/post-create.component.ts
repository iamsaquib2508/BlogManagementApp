import { Component, OnInit } from '@angular/core';
import { BlogService } from '../../services/blog.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { CreatePostDTO, UpdatePostDTO } from '../../models/post.dtos';
import { Post } from '../../models/post.model';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-post-create',
  standalone : true,
  imports : [ FormsModule, CommonModule ],
  templateUrl: './post-create.component.html',
  styleUrls: ['./post-create.component.css'],
})

export class PostCreateComponent implements OnInit {

  post : Post = {
    id : 0,
    title : '',
    content : '',
    author : '',
    createdAt : '',
  };
  isEditMode = false;
  postId?: number;


  constructor (private blogService : BlogService, 
    private router : Router,
    private route : ActivatedRoute,){ }

  ngOnInit(): void {
      this.route.paramMap.subscribe(params => {
        const idParam = params.get('id');
        if (idParam){
          // in edit
          this.isEditMode = true;
          this.postId = Number(idParam);

          this.blogService.getPostById(this.postId!).subscribe(post => {
            this.post = post;
          });
        }
      });
  }

  savePost() : void {

    if (this.isEditMode && this.postId) {
      this.blogService.updatePost(this.postId, this.post as UpdatePostDTO).subscribe({
        next : () => {
          this.router.navigate(['/posts', this.postId]);
        },
        error : err => console.error(`Error editing post ${this.postId}`, err)
      });
    } else {
      this.blogService.createPost(this.post as CreatePostDTO).subscribe({
        next: (created: Post) => {
          this.post = { id : 0, title: '', content: '' , author: '', createdAt : ''};
          this.router.navigate(['/posts']);
        },
        error: err => console.error('Error creating post', err)
      });
    }
  }
}
