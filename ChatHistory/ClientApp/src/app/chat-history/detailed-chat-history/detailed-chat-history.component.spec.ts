import { HttpClientModule } from '@angular/common/http';
import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { of } from 'rxjs';
import { ChatEvent } from 'src/app/models/chat-event';
import { EventType } from 'src/app/models/event-type';
import { User } from 'src/app/models/users';
import { ChatEventService } from 'src/app/services/chat-event.service';
import { DetailedChatHistoryComponent } from './detailed-chat-history.component';

describe('DetailedChatHistoryComponent', () => {
  let component: DetailedChatHistoryComponent;
  let fixture: ComponentFixture<DetailedChatHistoryComponent>;
  let chatEventService: ChatEventService;

  const fakeUser: User = {username: 'TestUser'};
  const fakeDate: Date = new Date();
  let chatEvents: ChatEvent[] = [{
    fromUser: fakeUser,
    type: EventType.Join,
    utcTimeStamp: fakeDate
  }]
  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule],
      declarations: [DetailedChatHistoryComponent],
      providers: [{ provide: ChatEventService, useValue: { getAll: () => of([]) } }]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    chatEventService = TestBed.inject(ChatEventService);
    fixture = TestBed.createComponent(DetailedChatHistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });

  it('should call ChatEventService.getAll() in ngOnInit()', () => {
    chatEventService.getAll = jasmine.createSpy().and.returnValue(of(chatEvents));
    component.ngOnInit();
    expect(chatEventService.getAll).toHaveBeenCalled();
  });

  it('should assign data to local variable when ngOnInit() is called', () => {
    chatEventService.getAll = jasmine.createSpy().and.returnValue(of(chatEvents));
    component.ngOnInit();
    expect(component.events).toEqual(chatEvents);
  });
});
