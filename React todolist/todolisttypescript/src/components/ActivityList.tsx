import React, { ReactNode } from 'react';
import { List, Checkbox } from 'antd';
import { Item } from './interfaces/Item';
import { ActivityListProps } from './interfaces/ActivityListProps';
import './style/ActivityListStyle.css';

const ActivityList: React.FC<ActivityListProps> = ({ items, onItemCheckChange, isDaily }) => {
  return (
    <List
      className="activity-list"
      dataSource={items}
      renderItem={(item, index) => {
        let label: ReactNode;
        let checkbox: ReactNode = null;

        if (typeof item === 'object') {
          label = (item as Item).name;
          checkbox = <Checkbox checked={(item as Item).checked} onChange={() => onItemCheckChange(index, isDaily)} />;
        } else {
          label = item as string;
          checkbox = <Checkbox onChange={() => onItemCheckChange(index, isDaily)} />;
        }

        return (
          <List.Item>
            <span className="activity-label">{label}</span>
            <div className="activity-checkbox">{checkbox}</div>
          </List.Item>
        );
      }}
    />
  );
}

export default ActivityList;
