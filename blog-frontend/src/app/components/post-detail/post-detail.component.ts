import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { Post } from '../../models/post.model';
import { PostService } from '../../services/post.service';

@Component({
  selector: 'app-post-detail',
  standalone: true,
  imports: [ CommonModule, RouterModule ],
  templateUrl: './post-detail.component.html',
  styleUrl: './post-detail.component.css'
})

export class PostDetailComponent {
  post? : Post;

  constructor (
    private route: ActivatedRoute,
    private postService: PostService,
  ) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    let post$ = this.postService.getPostById(id);
    post$.subscribe(post => {
      this.post = post;
    })
  }
}
