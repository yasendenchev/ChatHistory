import { User } from '../models/users';
import {ChatEvent } from '../models/chat-event';
import { ChatHistoryEntryPipe } from './chat-history-entry.pipe';
import { EventType } from '../models/event-type';

const user: User = {username: 'User'};
const date: Date = new Date();
const joinEvent: ChatEvent = {
  fromUser: user,
  type: EventType.Join,
  utcTimeStamp: date,
}

describe('ChatHistoryEntryPipe', () => {
  const pipe = new ChatHistoryEntryPipe();

  it('should be created', () => {
    expect(pipe).toBeTruthy();
  });

  it('should return correct value for Join event', () => {
    const joinEvent: ChatEvent = {
      fromUser: user,
      type: EventType.Join,
      utcTimeStamp: date,
    }
    const expectedResult: string = `${joinEvent.fromUser.username} enters the room`
    expect(pipe.transform(joinEvent)).toBe(expectedResult);
  });

  it('should return correct value for Comment event', () => {
    const commentEvent: ChatEvent = {
      fromUser: user,
      type: EventType.Comment,
      utcTimeStamp: date,
      commentContent: 'sample'
    }
    const expectedResult: string = `${commentEvent.fromUser.username} comments: "${commentEvent.commentContent}"`;
    expect(pipe.transform(commentEvent)).toBe(expectedResult);
  });

  it('should return correct value for Leave event', () => {
    const leaveEvent: ChatEvent = {
      fromUser: user,
      type: EventType.Leave,
      utcTimeStamp: date,
    }
    const expectedResult: string = `${leaveEvent.fromUser.username} leaves`;
    expect(pipe.transform(leaveEvent)).toBe(expectedResult);
  });
  
  it('should return correct value for High-Five event', () => {
    const highFiveEvent: ChatEvent = {
      fromUser: user,
      type: EventType.HighFive,
      utcTimeStamp: date,
      highFiveRecipient: user
    }
    const expectedResult: string = `${highFiveEvent.fromUser.username} high-fives ${highFiveEvent.highFiveRecipient!.username}`;
    expect(pipe.transform(highFiveEvent)).toBe(expectedResult);
  });
});
