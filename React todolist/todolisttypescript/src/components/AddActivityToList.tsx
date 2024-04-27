import React, { ChangeEvent, MouseEvent } from 'react';
import { Checkbox, Input, Button, Row, Col } from 'antd';
import { AddActivityProps } from './interfaces/AddActivityProps';


const AddActivity: React.FC<AddActivityProps> = ({ newItem, onNewItemChange, onAddClicked, isDaily, onIsDailyChange }) => {
  return (
    <Row align="middle">
      <Col>
        <Checkbox checked={isDaily} onChange={onIsDailyChange}>Dodaj Dzienne</Checkbox>
      </Col>
      <Col flex="auto">
        <Input value={newItem} onChange={onNewItemChange} />
      </Col>
      <Col>
        <Button onClick={onAddClicked}>Dodaj</Button>
      </Col>
    </Row>
  );
}

export default AddActivity;
