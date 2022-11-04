import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { ChatEvent } from '../models/chat-event';
import { ChatStatisticsDataByHour } from '../models/chat-statistics-data-by-hour';
import { EventType } from '../models/event-type';
import { User } from '../models/users';
import { ChatEventService } from './chat-event.service';

let service: ChatEventService;
let controller: HttpTestingController;
const fakeUser: User = { username: 'TestUser' };
const fakeDate: Date = new Date();


describe('ChatEventService', () => {

  beforeEach(() => {

    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [
        { provide: 'BASE_URL', useValue: 'sample/' },
        ChatEventService,
      ]
    });
    service = TestBed.inject(ChatEventService);
    controller = TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should call http GET with correct URL when getAll is invoked', () => {
    const expectedUrl: string = `sample/chat/allEvents`;
    service.getAll().subscribe();

    const request = controller.expectOne(expectedUrl);
    expect(request.request.method).toEqual('GET');

    controller.verify();

  });

  it('should return chatEvents when getAll is invoked', () => {
    const chatEvents: ChatEvent[] = [{
      fromUser: fakeUser,
      type: EventType.Join,
      utcTimeStamp: fakeDate
    }];
    const expectedUrl: string = `sample/chat/allEvents`;
    let data: ChatEvent[] = [];
    service.getAll().subscribe(res => {
      data = res;
    });
    
    const request = controller.expectOne(expectedUrl);
    request.flush(chatEvents);

    expect(data).toEqual(chatEvents);

  });

  it('should call http GET with correct URL when getChatStatisticsByHour is invoked', () => {
    const expectedUrl: string = `sample/chat/statistics/hour`;
    service.getChatStatisticsByHour().subscribe();

    const request = controller.expectOne(expectedUrl);
    expect(request.request.method).toEqual('GET');

    controller.verify();

  });

  it('should return chatEvents when getChatStatisticsByHour is invoked', () => {
    const chatStatisticsData: ChatStatisticsDataByHour[] = [{
      commentCount: 1,
      highFiveInitiatorsCount: 1,
      highFiveRecipientsCount: 1,
      joinedCount: 2,
      leftCount: 0,
      utcTimeStamp: fakeDate
    }];
    const expectedUrl: string = `sample/chat/statistics/hour`;
    let data: ChatStatisticsDataByHour[] = [];
    service.getChatStatisticsByHour().subscribe(res => {
      data = res;
    });
    
    const request = controller.expectOne(expectedUrl);
    request.flush(chatStatisticsData);

    expect(data).toEqual(chatStatisticsData);

  });
});
