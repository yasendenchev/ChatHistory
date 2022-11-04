import { HttpClientModule } from '@angular/common/http';
import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { of } from 'rxjs';
import { ChatStatisticsDataByHour } from 'src/app/models/chat-statistics-data-by-hour';
import { ChatEventService } from 'src/app/services/chat-event.service';
import { ChatStatisticsByHourComponent } from './chat-statistics-by-hour.component';

describe('ChatStatisticsByHourComponent', () => {
  let component: ChatStatisticsByHourComponent;
  let fixture: ComponentFixture<ChatStatisticsByHourComponent>;
  let chatEventService: ChatEventService;

  const chatStatisticsData: ChatStatisticsDataByHour[] = [{
    utcTimeStamp: new Date(),
    joinedCount: 1,
    leftCount: 1,
    highFiveRecipientsCount: 1,
    highFiveInitiatorsCount: 1,
    commentCount: 1,
  }];

  beforeEach(waitForAsync(() => {
     TestBed.configureTestingModule({
      imports: [HttpClientModule],
      declarations: [ChatStatisticsByHourComponent],
      providers: [{ provide: ChatEventService, useValue: { getChatStatisticsByHour: () => of([]) } }]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    chatEventService = TestBed.inject(ChatEventService);
    fixture = TestBed.createComponent(ChatStatisticsByHourComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });

  it('should call ChatEventService.getChatStatisticsByHour() in ngOnInit()', () => {
    chatEventService.getChatStatisticsByHour = jasmine.createSpy().and.returnValue(of(chatStatisticsData));
    component.ngOnInit();
    expect(chatEventService.getChatStatisticsByHour).toHaveBeenCalled();
  });

  it('should assign data to local variable when ngOnInit() is called', () => {
    chatEventService.getChatStatisticsByHour = jasmine.createSpy().and.returnValue(of(chatStatisticsData));
    component.ngOnInit();
    expect(component.hourlyData).toEqual(chatStatisticsData);
  });

});
