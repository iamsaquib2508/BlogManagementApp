// import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PostListComponent } from './components/post-list/post-list.component';
import { PostCreateComponent } from './components/post-create/post-create.component';
import { PostDetailComponent } from './components/post-detail/post-detail.component';

export const routes: Routes = [
    { path: '', redirectTo: 'posts', pathMatch: 'full' },
    { path: 'posts', component: PostListComponent },
    { path: 'posts/create', component: PostCreateComponent },
    { path: 'posts/:id/edit', component: PostCreateComponent },
    { path: 'posts/:id', component: PostDetailComponent },

];
