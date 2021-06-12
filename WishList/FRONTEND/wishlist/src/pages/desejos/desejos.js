import { Component } from 'react';

class Desejos extends Component{
    constructor(props){
        super(props);
        this.state = {
            listaDesejos : [],
            nomeDesejo : '',
            idDesejoAlterado : 0
        }
    }


    //  Puxar a lista da API
    buscarDesejos = () => {
        console.log('Chamando API')

        //  Colocar o link da listagem dos desejos
        fetch('http://localhost:5000/api/...')
        
        .then(resposta => resposta.json())

        .then(dados => this.setState({ 
            listaDesejos : dados 
        }))

        .catch(erro => console.log(erro))
    }


    //  Atualizar em tempo real
    atualizaNomeDesejo = (event) => {
        this.setState({ nomeDesejo : event.target.value })
    }

    //  Cadastrar
    cadastrarNovoDesejo = (event) => {
        event.preventDefault();

            fetch('http://localhost:5000/api/...', {
                method : 'POST',
    //                       Mudar de acordo com o a API ***
                body : JSON.stringify ( { Descricao : this.state.nomeDesejo } ),

                headers : {
                 "Content-Type" : "application/json"
                }
            })

        .then(console.log('Desejo cadastrado com sucesso!'))

        .catch(erro => console.log(erro))

        .then(this.state.buscarDesejos)
    }

    //  Editar Desejo
    
    editarDesejo = (event) => {
        event.preventDefault();

            fetch('http://localhost:5000/api/desejos/' + this.state.idDesejoAlterado, {

                method : 'PUT',

                body : JSON.stringify ( { Descricao : this.state.nomeDesejo } ),

                headers : {
                    "Content-Type" : "application/json"
                }
            })

            .then(resposta => {
                if (resposta.status === 204) {
                    console.log(
                    'Desejo' + this.state.idDesejoAlterado + 'atualizado com sucesso!'
                    )
                }
            })

        .then(this.state.buscarDesejos)

    }

    //  Excluir desejo
    excluirDesejo = (desejo) => {
            
            fetch('http://localhost:5000/api/desejos/' + desejo.idDesejo, {
                method : 'DELETE'
            })
    
            
            .then(resposta => {
                if (resposta.status === 204) {
                    console.log('Desejo' + desejo.idDesejo + 'excluído com sucesso!')
                }
            })

            .catch(erro => console.log(erro))

            .then(this.state.buscarDesejos)

    }


    //  Aparecer a lista automaticamente
    componentDidMount(){
        this.buscarDesejos();
    }

    buscarDesejoPorId = (desejo) => {
        this.setState({
            idDesejoAlterado : desejo.idDesejo,
            //           Mudar de acordo com o a API ***
            nomeDesejo : desejo.Descricao
        })
    }


    render(){
        return(
            <div>
                <main>
                    <section>
                        <h2>Seus desejos</h2>
                        <table>
                            <thead>
                                <tr>
                                    <th>#</th> {/* IDs */}
                                    <th>Desejo</th> {/* Desejos */}
                                    <th>Data de Criação</th> {/* Data de criação */}
                                    <th>Ações</th> {/* Ações */}
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    this.state.listaDesejos.map( (desejo) => {
                                        return (
                                            <tr key={desejo.desejoId}>
                                                <td>{desejo.desejoId}</td>
                                                <td>{desejo.nomeDesejo}</td>
                                                <td><button onClick={() => this.buscarDesejoPorId(desejo)}>Editar</button></td>
                                                <td><button onClick={() => this.excluirDesejo(desejo)}>Excluir</button></td>


                                            </tr>
                                        )
                                    } )
                                }
                            </tbody>
                        </table>
                    </section>
                    <h2>Adicionar Desejo</h2>

                    <form onSubmit={this.cadastrarNovoDesejo}>
                        <div>
                            <input 
                                type= 'text'
                                value={this.state.nomeDesejo}
                                onChange={this.atualizaNomeDesejo}
                                placeholder="Desejo"
                            />

                            <button type="submit">Adicionar</button>
                        </div>
                    </form>
                </main>
            </div>
        )
    }
}

export default Desejos;