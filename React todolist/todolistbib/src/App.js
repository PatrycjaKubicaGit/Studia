import logo from './logo.svg';
import './App.css';
import TodoList from './components/todolist';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        {/*<Hello />*/} 
        <TodoList/>
      </header>
    </div>
  );
}

export default App;
