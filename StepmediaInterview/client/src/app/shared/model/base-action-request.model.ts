export class BaseActionRequest {
    public constructor(
      public fromAction: string,
      public payload: any,
    ) {}
  }