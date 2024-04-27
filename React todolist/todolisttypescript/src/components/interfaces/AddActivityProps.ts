import { ChangeEvent, MouseEvent } from 'react';
import { CheckboxChangeEvent } from 'antd/lib/checkbox';

export interface AddActivityProps {
  newItem: string;
  onNewItemChange: (e: ChangeEvent<HTMLInputElement>) => void;
  onAddClicked: (e: MouseEvent<HTMLElement>) => void;
  isDaily: boolean;
  onIsDailyChange: (e: CheckboxChangeEvent) => void;
}