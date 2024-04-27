import React from 'react';
import { Select } from 'antd';

const { Option } = Select;

const Filter = ({ filter, onFilterChange }) => {
  return (
    <Select style={{ margin: '0 10px' }} value={filter} onChange={onFilterChange}>
      <Option value="Wszystkie">Wszystkie</Option>
      <Option value="Dzienne">Dzienne</Option>
      <Option value="Jednorazowe">Jednorazowe</Option>
    </Select>
  );
}

export default Filter;
