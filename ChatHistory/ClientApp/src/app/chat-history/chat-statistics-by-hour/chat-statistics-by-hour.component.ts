import { Component, OnInit } from '@angular/core';
import { ChatStatisticsDataByHour } from 'src/app/models/chat-statistics-data-by-hour';
import { ChatEventService } from 'src/app/services/chat-event.service';

@Component({
  selector: 'app-chat-statistics-by-hour',
  templateUrl: './chat-statistics-by-hour.component.html',
  styleUrls: ['./chat-statistics-by-hour.component.css']
})
export class ChatStatisticsByHourComponent implements OnInit {
  public hourlyData: ChatStatisticsDataByHour[] = [];
  private chatEventService: ChatEventService

  constructor(chatEventService: ChatEventService) {
    this.chatEventService = chatEventService;
  }
  ngOnInit(): void {
    this.chatEventService.getChatStatisticsByHour()
      .subscribe(res => this.hourlyData = res);
  }
}
