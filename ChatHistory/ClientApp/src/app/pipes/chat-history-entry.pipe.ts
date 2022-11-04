
import { Pipe, PipeTransform } from '@angular/core';
import { ChatEvent } from '../models/chat-event';
import { EventType } from '../models/event-type';

@Pipe({
  name: 'chatHistoryEntry'
})
export class ChatHistoryEntryPipe implements PipeTransform {
  transform(value: ChatEvent): string {
    switch (value.type) {
      case (EventType.Join):
        return `${value.fromUser.username} enters the room`;
      case (EventType.Leave):
        return `${value.fromUser.username} leaves`;
      case (EventType.Comment):
        return `${value.fromUser.username} comments: "${value.commentContent}"`;
      case (EventType.HighFive):
        return `${value.fromUser.username} high-fives ${value.highFiveRecipient!.username}`;
      default:
        return `(invalid data)`;
    }
  }

}
