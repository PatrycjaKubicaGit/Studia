import React from 'react';
import { Select } from 'antd';
import { FilterProps } from './interfaces/FilterProps';

const { Option } = Select;


const Filter: React.FC<FilterProps> = ({ filter, onFilterChange }) => {
  return (
    <Select style={{ margin: '0 10px' }} value={filter} onChange={onFilterChange}>
      <Option value="Wszystkie">Wszystkie</Option>
      <Option value="Dzienne">Dzienne</Option>
      <Option value="Jednorazowe">Jednorazowe</Option>
    </Select>
  );
}

export default Filter;
