import {Injectable, OnDestroy} from '@angular/core';
import {Subscription} from 'rxjs';

@Injectable({
    providedIn: 'root'
  })
export class AutoUnsubscribeComponent implements OnDestroy {
    protected subscriptions: Subscription[] = [];

    public ngOnDestroy(): void {
        for (const subscription of this.subscriptions) {
            subscription.unsubscribe();
        }
    }

    protected safeSubscriptions(subs: Subscription[]) {
        this.subscriptions.push(...subs);
    }
}