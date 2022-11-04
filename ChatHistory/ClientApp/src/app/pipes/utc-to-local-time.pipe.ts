import { Pipe, PipeTransform } from '@angular/core';
import { UtcToLocalDateTimeFormat } from './models/date-format';

@Pipe({
  name: 'utcToLocalTime'
})
export class UtcToLocalTimePipe implements PipeTransform {

  transform(utcDate: Date, format: string | UtcToLocalDateTimeFormat): string {
    let browserLanguage = navigator.language;
    let date = new Date(utcDate.toString());

    switch (format) {
      case (UtcToLocalDateTimeFormat.Full):
        let fullDate = date.toLocaleDateString(browserLanguage);
        let fullTime = date.toLocaleTimeString(browserLanguage, { hour: '2-digit', minute: '2-digit' });
        return `${fullDate}, ${fullTime}`;
      case (UtcToLocalDateTimeFormat.Short):
        let shortDate = date.toLocaleDateString(browserLanguage, { day: 'numeric', month:'short', year:'numeric'});
        let shortTime = date.toLocaleTimeString(browserLanguage, { hour: 'numeric'});
        return `${shortDate} - ${shortTime}`;
      default:
        return ``;
    }
  }

}
