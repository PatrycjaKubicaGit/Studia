import React from 'react';
import { Checkbox, Input, Button, Row, Col } from 'antd';

const AddActivity = ({ newItem, onNewItemChange, onAddClicked, isDaily, onIsDailyChange }) => {
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
