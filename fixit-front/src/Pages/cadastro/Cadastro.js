import React, { Component } from 'react';
import axios from 'axios';

class Cadastro extends Component{
  constructor(props){
    super(props);
    this.state = {
      email : '',
      senha : '',
      tipoUser : '',
      errorMensagem : '',
      isLoading : false
    }
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

              <form onSubmit={this.efetuaCadastro}>
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

                <input
                  type="checkbox"
                  name="Prestador"
                  checked={this.state.tipoUser}
                  onChange={this.AtualizaStateCampo}
                />

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
                    Cadastre-se
                  </button>
                }
              </form>
          </section>
        </main>
      </div>
    )
  }
}

export default Cadastro;