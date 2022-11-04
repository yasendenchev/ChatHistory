import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './shared/home/nav-menu/nav-menu.component';
import { HomeComponent } from './shared/home/home.component';
import { ChatHistoryEntryPipe } from './pipes/chat-history-entry.pipe';
import { UtcToLocalTimePipe } from './pipes/utc-to-local-time.pipe';
import { ChatEventService } from './services/chat-event.service';
import { DetailedChatHistoryComponent } from './chat-history/detailed-chat-history/detailed-chat-history.component';
import { ChatStatisticsByHourComponent } from './chat-history/chat-statistics-by-hour/chat-statistics-by-hour.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    DetailedChatHistoryComponent,
    ChatStatisticsByHourComponent,
    ChatHistoryEntryPipe,
    UtcToLocalTimePipe
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'history/detailed', component: DetailedChatHistoryComponent },
      { path: 'statistics/byHour', component: ChatStatisticsByHourComponent },
    ])
  ],
  providers: [ChatEventService],
  bootstrap: [AppComponent]
})
export class AppModule { }
