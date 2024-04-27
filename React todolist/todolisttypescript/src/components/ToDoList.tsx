import React, { useState, useEffect, ChangeEvent, MouseEvent } from 'react';
import { Checkbox, Button, Input, Select } from 'antd';
import ActivityList from './ActivityList';
import AddActivity from './AddActivityToList';
import Filter from './Filter';
import './style/TodolistStyle.css';
import { CheckboxChangeEvent } from 'antd/lib/checkbox';
import { Item } from './interfaces/Item';


function TodoList() {
  const [dailyItems, setDailyItems] = useState<Item[]>(["Śniadanie", "Praca", "Obiad", "Ćwiczenia", "Kolacja", "Mycie", "Spanie"].map(item => ({ name: item, checked: false })));
  const [oneTimeItems, setOneTimeItems] = useState<Item[]>(["Odbierz pocztę", "Umyj podłogi", "Zatankuj Samochód"].map(item => ({ name: item, checked: false })));
  const [newItem, setNewItem] = useState<string>("");
  const [isDaily, setIsDaily] = useState<boolean>(false);
  const [filter, setFilter] = useState<string>("Wszystkie");

  useEffect(() => {
    const endOfDayTimer = setInterval(() => {
      const now = new Date();
      if (now.getHours() === 0 && now.getMinutes() === 0 && now.getSeconds() === 0) {
        onEndDayClicked();
      }
    }, 1000);

    return () => clearInterval(endOfDayTimer);
  }, []);

  const onAddClicked = () => {
    if (newItem) {
      if (isDaily) {
        setDailyItems([...dailyItems, { name: newItem, checked: false }]);
      } else {
        setOneTimeItems([...oneTimeItems, { name: newItem, checked: false }]);
      }
      setNewItem("");
    }
  };

  const onEndDayClicked = () => {
    setDailyItems(dailyItems.map(item => ({ ...item, checked: false })));
    setOneTimeItems([]);
  };

  const onNewItemChange = (event: ChangeEvent<HTMLInputElement>) => {
    setNewItem(event.target.value);
  };

  const onIsDailyChange = (event: CheckboxChangeEvent) => {
    setIsDaily(event.target.checked);
  };

  const onItemCheckChange = (index: number, isDaily: boolean) => {
    if (isDaily) {
      setDailyItems(dailyItems.map((item, i) => i === index ? { ...item, checked: !item.checked } : item));
    } else {
      setOneTimeItems(oneTimeItems.map((item, i) => i === index ? { ...item, checked: !item.checked } : item));
    }
  };

  const onFilterChange = (value: string) => {
    setFilter(value);
  };

  const dailyItemListItems = dailyItems.filter(item => filter === "Wszystkie" || filter === "Dzienne");
  const oneTimeItemListItems = oneTimeItems.filter(item => filter === "Wszystkie" || filter === "Jednorazowe");

  return (
    <div>
      <div>
      <div className="Menu">
          <AddActivity
            newItem={newItem}
            onNewItemChange={onNewItemChange}
            onAddClicked={onAddClicked}
            onIsDailyChange={onIsDailyChange}
            isDaily={isDaily}
          />
          <Filter filter={filter} onFilterChange={onFilterChange} />
          <Button onClick={onEndDayClicked}>Zakończ dzień</Button>
        </div>
      </div>
      <div className="lista">
        {filter !== "Jednorazowe" && (
          <div>
            <h4>Dzienne aktywności</h4>
            <ActivityList items={dailyItemListItems} onItemCheckChange={onItemCheckChange} isDaily={true} />
          </div>
        )}
        {filter !== "Dzienne" && (
          <div>
            <h4>Jednorazowe zadania</h4>
            <ActivityList items={oneTimeItemListItems} onItemCheckChange={onItemCheckChange} isDaily={false} />
          </div>
        )}
      </div>
    </div>
  );
}

export default TodoList;
