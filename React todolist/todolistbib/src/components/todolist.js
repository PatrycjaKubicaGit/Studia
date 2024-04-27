import React, { useState, useEffect } from 'react';
import { List, Checkbox, Button, Input, Select } from 'antd';
import ActivityList from './ActivityList';
import AddActivity from './AddActivityToList';
import Filter from './Filter';
import './TodolistStyle.css';

function TodoList() {
  const [dailyItems, setDailyItems] = useState(["Śniadanie", "Praca", "Obiad", "Ćwiczenia", "Kolacja", "Mycie", "Spanie"].map(item => ({ name: item, checked: false })));
  const [oneTimeItems, setOneTimeItems] = useState(["Odbierz pocztę", "Umyj podłogi", "Zatankuj Samochód"]);
  const [newItem, setNewItem] = useState("");
  const [isDaily, setIsDaily] = useState(false);
  const [filter, setFilter] = useState("Wszystkie");

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
        setOneTimeItems([...oneTimeItems, newItem]);
      }
      setNewItem("");
    }
  };

  const onEndDayClicked = () => {
    setDailyItems(dailyItems.map(item => ({ ...item, checked: false })));
    setOneTimeItems([]);
  };

  const onNewItemChange = (event) => {
    setNewItem(event.target.value);
  };

  const onIsDailyChange = (event) => {
    setIsDaily(event.target.checked);
  };

  const onItemCheckChange = (index, isDaily) => {
    if (isDaily) {
      setDailyItems(dailyItems.map((item, i) => i === index ? { ...item, checked: !item.checked } : item));
    } else {
      setOneTimeItems(oneTimeItems.map((item, i) => i === index ? { ...item, checked: !item.checked } : item));
    }
  };

  const onFilterChange = (event) => {
    setFilter(event.target.value);
  };

  const dailyItemListItems = dailyItems.filter(item => filter === "Wszystkie" || filter === "Dzienne");
  const oneTimeItemListItems = oneTimeItems.filter(item => filter === "Wszystkie" || filter === "Jednorazowe");

  return (
    <div>
      <div>
      <div class="Menu">
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
      <div class="lista">
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
