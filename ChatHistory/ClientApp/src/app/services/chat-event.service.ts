import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { ChatEvent } from "../models/chat-event";
import { ChatStatisticsDataByHour } from "../models/chat-statistics-data-by-hour";

@Injectable()
export class ChatEventService {
    public readonly baseUrl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = `${baseUrl}chat/`;
    }

    getAll() {
        return this.http.get<ChatEvent[]>(`${this.baseUrl}allEvents`);
    }

    getChatStatisticsByHour() {
        return this.http.get<ChatStatisticsDataByHour[]>(`${this.baseUrl}statistics/hour`);
    }
}