import { UtcToLocalTimePipe } from './utc-to-local-time.pipe';

describe('UtcToLocalTimePipe', () => {
  it('should be created', () => {
    const pipe = new UtcToLocalTimePipe();
    expect(pipe).toBeTruthy();
  });
});
