import React, {Component} from 'react';
import './App.css';
import { cars } from './demo';
import axios from 'axios';
import { Header, Icon, List } from 'semantic-ui-react'
import { listenerCount } from 'process';

class myObejct
{
   id : number = 0;
   name : string = "";

   constructor(_id: number, _name: string) {
     this.id = _id;
     this.name = _name;
   }
}

class App extends Component {

  state = {
    values: []
  }

  componentDidMount()
  {
    axios.get('http://localhost:5000/api/values')
      .then((response) => {
        //console.log(response);
        this.setState({
          values: response.data
        });

      })
  }

  render() {
    let LetsDisplay =  cars.map((car) => {
      return <li>{car.color}</li>
    });

    return (
    <div>

          <Header as='h2' icon>
            <Icon name='settings' />
            Account Settings
            <Header.Subheader>
              Manage your account settings and set e-mail preferences.
            </Header.Subheader>
          </Header>
          <List>
            {
                this.state.values.map((val: any) => {
                    return <List.Item key={val.id}>{val.name}</List.Item>;
                })
            }
          </List>
    </div>
    );
  }
}

export default App;
