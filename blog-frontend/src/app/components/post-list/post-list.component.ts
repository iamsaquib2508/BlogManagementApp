import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { BlogService } from '../../services/blog.service';
import { Post } from '../../models/post.model';

@Component({
  selector: 'app-post-list',
  standalone : true,
  imports : [ RouterLink, CommonModule ],
  templateUrl: './post-list.component.html',
  styleUrl: './post-list.component.css'
})
export class PostListComponent implements OnInit {
  posts: Post[] = [];

  constructor(private blogService: BlogService) { }

  ngOnInit(): void {
      this.blogService.getPosts().subscribe({
        next: data => {
          this.posts = data;
          console.log(data);
        },
        error: err => console.error('Error fetching posts', err)
      });
  }
}
