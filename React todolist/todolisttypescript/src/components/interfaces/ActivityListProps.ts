import { Item } from './Item';

export interface ActivityListProps {
  items: (string | Item)[];
  onItemCheckChange: (index: number, isDaily: boolean) => void;
  isDaily: boolean;
}
