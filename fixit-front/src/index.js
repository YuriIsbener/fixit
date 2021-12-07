import React from 'react';
import { render } from 'react-dom';
import { Route, BrowserRouter, Routes } from 'react-router-dom';

import './index.css';

import Login from './Pages/login/Login';
import Home from './Pages/home/Home'
import Cadastro from './Pages/cadastro/Cadastro'
import NotFound from './Pages/notFound/NotFound';

render(
  <BrowserRouter>
      <div>
        <Routes>
          <Route exact path='/' element={<Login/>} />
          <Route exact path='/home' element={<Home/>} />
          <Route exact path='/cadastro' element={<Cadastro/>} />
          <Route exact path='/notfound'  element={<NotFound/>} />
        </Routes>
      </div>
  </BrowserRouter>,

  document.getElementById('root')
)


