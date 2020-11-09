import './App.css';
import Home from './components/Home'
import AddQuestionForm from './components/AddQuestionForm'
import Question from './components/Question'

import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from "react-router-dom";

function App() {
return (
  <Router>
    <Switch>
    <Route exact path="/">
        <Home />
        </Route>
      <Route exact path="/add">
        <AddQuestionForm />
      </Route>
      <Route exact path="/question/:id">
          <Question />
        </Route>
    </Switch>
  </Router>
);
}

export default App;
