import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Post } from '../models/post.model';
import { CreatePostDTO, UpdatePostDTO } from '../models/post.dtos';

@Injectable({
  providedIn: 'root'
})

export class BlogService {

  private apiUrl = 'http://localhost:5099/api/posts';

  constructor(private http: HttpClient) { }

  getPosts(): Observable<Post[]> {
    return this.http.get<Post[]>(this.apiUrl);
  }

  createPost(post: CreatePostDTO): Observable<Post> {
    return this.http.post<Post>(this.apiUrl, post);
  }

  getPostById(id: number): Observable<Post> {
    return this.http.get<Post>(`${this.apiUrl}/${id}`);
  }

  updatePost(id : number, post : UpdatePostDTO) : Observable<Post>{
    return this.http.put<Post>(`${this.apiUrl}/${id}`, post);
  }
}
