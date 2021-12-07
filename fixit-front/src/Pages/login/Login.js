import './Login.css';

import React, { Component } from 'react';
import axios from 'axios';

class Login extends Component{
  constructor(props){
    super(props);
    this.state = {
      email : '',
      senha : '',
      errorMensagem : '',
      isLoading : false
    }
  }

  efetuaLogin = (event) => {
      event.preventDefault();

      this.setState({ erroMensagem : '', isLoading : true })

      axios.post('http://localhost:5000/api/Login', {
        email : this.state.email,
        senha : this.state.senha
      })

      .then(resposta => {
        if (resposta.status === 200){
          localStorage.setItem('token-usuario', resposta.data.token)
          this.setState({ isLoading : false })
        }
      })

      .catch(() => {
        this.setState({ erroMensagem : 'E-mail ou senha inválidos! Tente novamente.', isLoading : false })
      })
  }

  atualizaStateCampo = (event) => {
    this.setState({ [event.target.name] : event.target.value })
  }

  render(){
    return(
      <div>
        <main>
          <section>

              <image src=""/>

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

                <p>{this.state.errorMensagem}</p>

                {
                  this.state.isLoading === true &&
                  <button type="submit" disabled>Loading...</button>
                }
                {
                  this.state.isLoading === false &&
                  <button 
                    type="submit"
                    disabled={ this.state.email === '' || this.state.senha === '' ? 'none' : ''}
                  >
                    Login
                  </button>
                }
              </form>
          </section>
        </main>
      </div>
    )
  }
}

export default Login;
