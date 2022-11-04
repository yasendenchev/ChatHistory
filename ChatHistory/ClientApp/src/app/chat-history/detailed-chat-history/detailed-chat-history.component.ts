import { Component, OnInit } from '@angular/core';
import { ChatEvent } from '../../models/chat-event';
import { ChatStatisticsDataByHour } from '../../models/chat-statistics-data-by-hour';
import { ChatEventService } from '../../services/chat-event.service';

@Component({
  selector: 'app-detailed-chat-history',
  templateUrl: './detailed-chat-history.component.html',
  styleUrls: ['./detailed-chat-history.component.css']
})
export class DetailedChatHistoryComponent implements OnInit {
  public events: ChatEvent[] = [];
  private chatEventService: ChatEventService

  constructor(chatEventService: ChatEventService) {
    this.chatEventService = chatEventService;
  }
  
  ngOnInit(): void {
    this.chatEventService.getAll()
      .subscribe(res => this.events = res);
  }
}
