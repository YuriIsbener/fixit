(this["webpackJsonpfixit-front"]=this["webpackJsonpfixit-front"]||[]).push([[0],{30:function(t,e,a){},31:function(t,e,a){},51:function(t,e,a){"use strict";a.r(e);var n=a(0),s=a(24),i=a(25),o=a(2),c=(a(30),a(13)),r=a(5),h=a(6),j=a(8),l=a(7),u=(a(31),a(10)),d=a.n(u),b=a(1),m=function(t){Object(j.a)(a,t);var e=Object(l.a)(a);function a(t){var n;return Object(r.a)(this,a),(n=e.call(this,t)).efetuaLogin=function(t){t.preventDefault(),n.setState({erroMensagem:"",isLoading:!0}),d.a.post("http://localhost:5000/api/Login",{email:n.state.email,senha:n.state.senha}).then((function(t){200===t.status&&(localStorage.setItem("token-usuario",t.data.token),n.setState({isLoading:!1}))})).catch((function(){n.setState({erroMensagem:"E-mail ou senha inv\xe1lidos! Tente novamente.",isLoading:!1})}))},n.atualizaStateCampo=function(t){n.setState(Object(c.a)({},t.target.name,t.target.value))},n.state={email:"",senha:"",errorMensagem:"",isLoading:!1},n}return Object(h.a)(a,[{key:"render",value:function(){return Object(b.jsx)("div",{children:Object(b.jsx)("main",{children:Object(b.jsxs)("section",{children:[Object(b.jsx)("image",{src:""}),Object(b.jsxs)("p",{children:["Bem Vindo(a), ",Object(b.jsx)("br",{})," a plataforma de suporte t\xe9cnico do SENAI"]}),Object(b.jsxs)("form",{onSubmit:this.efetuaLogin,children:[Object(b.jsx)("input",{type:"text",name:"email",value:this.state.email,onChange:this.atualizaStateCampo,placeholder:"E-mail"}),Object(b.jsx)("input",{type:"password",name:"senha",value:this.state.senha,onChange:this.atualizaStateCampo,placeholder:"Senha"}),Object(b.jsx)("p",{children:this.state.errorMensagem}),!0===this.state.isLoading&&Object(b.jsx)("button",{type:"submit",disabled:!0,children:"Loading..."}),!1===this.state.isLoading&&Object(b.jsx)("button",{type:"submit",disabled:""===this.state.email||""===this.state.senha?"none":"",children:"Login"})]})]})})})}}]),a}(n.Component),p=function(t){Object(j.a)(a,t);var e=Object(l.a)(a);function a(t){var n;return Object(r.a)(this,a),(n=e.call(this,t)).state={},n}return Object(h.a)(a,[{key:"render",value:function(){return Object(b.jsx)("div",{children:Object(b.jsx)("h1",{children:"Home Page"})})}}]),a}(n.Component),O=function(t){Object(j.a)(a,t);var e=Object(l.a)(a);function a(t){var n;return Object(r.a)(this,a),(n=e.call(this,t)).efetuaCadastro=function(t){t.preventDefault(),n.setState({erroMensagem:"",isLoading:!0}),d.a.post("http://localhost:5000/api/Usuario",{nome:n.state.nome,email:n.state.email,senha:n.state.senha,tipoUser:n.state.tipoUser}).then((function(t){200===t.status&&n.setState({isLoading:!1})})).catch((function(){n.setState({erroMensagem:"Informa\xe7\xf5es inv\xe1lidas! Tente novamente.",isLoading:!1})}))},n.atualizaStateCampo=function(t){n.setState(Object(c.a)({},t.target.name,t.target.value))},n.state={nome:"",email:"",senha:"",tipoAcc:!1,tipoUser:!1,errorMensagem:"",isLoading:!1},n}return Object(h.a)(a,[{key:"render",value:function(){return Object(b.jsx)("div",{children:Object(b.jsx)("main",{children:Object(b.jsxs)("section",{children:[Object(b.jsx)("image",{src:""}),Object(b.jsxs)("p",{children:["Bem Vindo(a), ",Object(b.jsx)("br",{})," a plataforma de suporte t\xe9cnico do SENAI"]}),Object(b.jsxs)("form",{onSubmit:this.efetuaCadastro,children:[Object(b.jsx)("input",{type:"text",name:"email",value:this.state.email,onChange:this.AtualizaStateCampo,placeholder:"E-mail"}),Object(b.jsx)("input",{type:"password",name:"senha",value:this.state.senha,onChange:this.AtualizaStateCampo,placeholder:"Senha"}),Object(b.jsx)("p",{children:this.state.errorMensagem}),Object(b.jsx)("input",{type:"checkbox",name:"Prestador",checked:this.state.tipoUser,onChange:this.AtualizaStateCampo}),Object(b.jsx)("input",{type:"checkbox",name:"Colaborador",checked:this.state.tipoUser,onChange:this.AtualizaStateCampo}),!0===this.state.isLoading&&Object(b.jsx)("button",{type:"submit",disabled:!0,children:"Loading..."}),!1===this.state.isLoading&&Object(b.jsx)("button",{type:"submit",disabled:""===this.state.email||""===this.state.senha?"none":"",children:"Cadastre-se"})]})]})})})}}]),a}(n.Component);var x=function(){return Object(b.jsx)("h1",{children:"404 - Not Found"})};Object(s.render)(Object(b.jsx)(i.a,{children:Object(b.jsx)("div",{children:Object(b.jsxs)(o.c,{children:[Object(b.jsx)(o.a,{exact:!0,path:"/",element:Object(b.jsx)(m,{})}),Object(b.jsx)(o.a,{exact:!0,path:"/home",element:Object(b.jsx)(p,{})}),Object(b.jsx)(o.a,{exact:!0,path:"/cadastro",element:Object(b.jsx)(O,{})}),Object(b.jsx)(o.a,{exact:!0,path:"/notfound",element:Object(b.jsx)(x,{})})]})})}),document.getElementById("root"))}},[[51,1,2]]]);
//# sourceMappingURL=main.8b0fd97d.chunk.js.map