import React from 'react';
import ReactDOM from 'react-dom';
import { Route, BrowserRouter as Router, Switch, Redirect } from 'react-router-dom';

import './index.css';

import Login from './Pages/login/Login';
import Home from './Pages/home/Home'
import Cadastro from './Pages/cadastro/Cadastro'
import NotFound from './Pages/notFound/NotFound';

const routing = (
  <Router>
      <div>
        <Switch>
          <Route exact path="/" component={Login} />
          <Route exact path="/home" component={Home} />
          <Route exact path="/cadastro" component={Cadastro} />
          <Route exact path="/notfound" component={NotFound} />
          <Redirect to= "/notfound"/>
        </Switch>
      </div>
  </Router>
)

ReactDOM.render(routing ,document.getElementById('root'));
