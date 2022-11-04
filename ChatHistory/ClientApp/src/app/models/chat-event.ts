import { EventType } from "./event-type"
import { User } from "./users"

export interface ChatEvent {
  fromUser: User
  type: EventType
  utcTimeStamp: Date
  highFiveRecipient?: User
  commentContent?: string
}