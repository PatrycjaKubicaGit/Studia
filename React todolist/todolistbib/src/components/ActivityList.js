import React from 'react';
import { List, Checkbox } from 'antd';

const ActivityList = ({ items, onItemCheckChange, isDaily }) => {
  return (
    <List
      dataSource={items}
      renderItem={(item, index) => (
        <List.Item>
          <span>{isDaily && typeof item === 'object' ? item.name : item}</span>
          {isDaily && typeof item === 'object' && (
            <Checkbox checked={item.checked} onChange={() => onItemCheckChange(index, isDaily)} />
          )}
        </List.Item>
      )}
    />
  );
}

export default ActivityList;
