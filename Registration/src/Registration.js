import React from 'react';
import axios from 'axios';

export default class Registration extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      firstName: '',
      lastName: '',
      npiNumber: '',
      address1: '',
      address2: '',
      city: '',
      state: '',
      zip: '',
      telephone: '',
      email: '',
    };
  }

  handleChange(evt) {
    this.setState({
      [evt.target.name]: evt.target.value
    });
  }

  async saveRegistration(evt) {
    evt.preventDefault();
    try {
      await axios.post('https://somebackendurl.com/registration', this.state);
    } catch (err) {
      console.log(err);
    }
  }

  render() {
    return (
      <div>
        <form onSubmit={(evt) => this.saveRegistration(evt)}>
          <div>
            <label for="firstName">First Name:</label>
            <input type="text" id="firstName" name="firstName" value={this.state.firstName} onChange={(evt) => this.handleChange(evt)} />
          </div>
          <div>
            <label for="lastName">Last Name:</label>
            <input type="text" id="lastName" name="lastName" value={this.state.lastName} onChange={(evt) => this.handleChange(evt)} />
          </div>
          <div>
            <label for="npiNumber">NPI Number:</label>
            <input type="text" id="npiNumber" name="npiNumber" value={this.state.npiNumber} onChange={(evt) => this.handleChange(evt)} />
          </div>
          <div>
            <label for="address1">Address 1:</label>
            <input type="text" id="address1" name="address1" value={this.state.address1} onChange={(evt) => this.handleChange(evt)} />
          </div>
          <div>
            <label for="address2">Address 2:</label>
            <input type="text" id="address2" name="address2" value={this.state.address2} onChange={(evt) => this.handleChange(evt)} />
          </div>
          <div>
            <label for="city">City:</label>
            <input type="text" id="city" name="city" value={this.state.city} onChange={(evt) => this.handleChange(evt)} />
          </div>
          <div>
            <label for="state">State:</label>
            <input type="text" id="state" name="state" value={this.state.state} onChange={(evt) => this.handleChange(evt)} />
          </div>
          <div>
            <label for="zip">Zip:</label>
            <input type="text" id="zip" name="zip" value={this.state.zip} onChange={(evt) => this.handleChange(evt)} />
          </div>
          <div>
            <label for="telephone">Telephone:</label>
            <input type="text" id="telephone" name="telephone" value={this.state.telephone} onChange={(evt) => this.handleChange(evt)} />
          </div>
          <div>
            <label for="email">Email:</label>
            <input type="text" id="email" name="email" value={this.state.email} onChange={(evt) => this.handleChange(evt)} />
          </div>
          <div>
            <button type="submit">Register</button>
          </div>
        </form>
      </div>
    )
  }
}