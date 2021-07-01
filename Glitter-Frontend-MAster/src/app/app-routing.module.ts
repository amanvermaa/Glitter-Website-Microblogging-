import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { MyTweetsComponent } from './my-tweets/my-tweets.component';
import { FollowersComponent } from './followers/followers.component';
import { FollowingComponent } from './following/following.component';
import { EditTweetComponent } from './edit-tweet/edit-tweet.component';
import { AnalyticsComponent } from './analytics/analytics.component';
import { SearchComponent } from './search/search.component';



const routes: Routes = [
  {path: '' , redirectTo:'/login', pathMatch:'full'},
  {path: 'createTweet', component:DashboardComponent,pathMatch:'full'},
  {path: 'register', component:RegisterComponent , pathMatch:'full'},
  {path: 'login',  component:LoginComponent , pathMatch:'full'  },
  {path: 'playground/dashboard/:id ',component:DashboardComponent,pathMatch:'full'},
  {path:'myTweets/:id',component:MyTweetsComponent,pathMatch:'full'},
  {path:'allFollowers/:id',component:FollowersComponent,pathMatch:'full'},
  {path:'allFollowing/:id',component:FollowingComponent,pathMatch:'full'},
  {path:'editTweet',component:EditTweetComponent,pathMatch:'full'},
  {path:'analytics',component:AnalyticsComponent,pathMatch:'full'}, 
  {path: "searchUser/:text" , component:SearchComponent , pathMatch:'full'},
  {path: "**" , component:PageNotFoundComponent , pathMatch:'full'},  
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
