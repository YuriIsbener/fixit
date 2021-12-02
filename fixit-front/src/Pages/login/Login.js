import './Login.css';

import { Component } from 'react';
import axios from 'axios';

class Login extends Component{
  constructor(props){
    super(props);
    this.state = {
      email : '',
      senha : ''
    }
  }

  efetuaLogin (event) => {
      event.preventDefault();

      axios.post('http://localhost:5000')
  }

  render(){
    return(
      <div>
        <main>
          <section>
              <p>Bem Vindo(a), <br/> a plataforma de suporte técnico do SENAI</p>

              <form onSubmit={this.efetuaLogin}>
                <input
                  type="text"
                  name="email"
                  value={this.state.email}
                  onChange={this.AtualizaStateCampo}
                  placeholder="E-mail"
                />

                <input
                  type="password"
                  name="senha"
                  value={this.state.senha}
                  onChange={this.AtualizaStateCampo}
                  placeholder="Senha"
                />

                <button type="submit">
                  Login
                </button>
              </form>
          </section>
        </main>
      </div>
    )
  }
}

export default Login;
