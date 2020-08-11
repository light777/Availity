import React from 'react';
import axios from 'axios';
import { useForm } from 'react-hook-form';
import './Registration.css';

export default () => {
  const { handleSubmit, register, errors } = useForm();
  const onSubmit = async (data) => {
    try {
      console.log(data);
      await axios.post('https://somebackendurl.com/registration', data);
    } catch (err) {
      console.log(err);
    }
  }

  return (
    <div>
      <form onSubmit={handleSubmit(onSubmit)}>
        <div>
          <label htmlFor="firstName">First Name:</label>
          <input type="text" id="firstName" name="firstName" ref={register({ required: true })} />
          <span>{ errors.firstName && "First Name is required" }</span>
        </div>
        <div>
          <label htmlFor="lastName">Last Name:</label>
          <input type="text" id="lastName" name="lastName" ref={register({ required: true })} />
          <span>{ errors.lastName && "Last Name is required" }</span>
        </div>
        <div>
          <label htmlFor="npiNumber">NPI Number:</label>
          <input type="text" id="npiNumber" name="npiNumber" ref={register({ required: true })} />
          <span>{ errors.npiNumber && "NPI Number is required" }</span>
        </div>
        <div>
          <label htmlFor="address1">Address 1:</label>
          <input type="text" id="address1" name="address1" ref={register({ required: true })} />
          <span>{ errors.address1 && "Address is required" }</span>
        </div>
        <div>
          <label htmlFor="address2">Address 2:</label>
          <input type="text" id="address2" name="address2" ref={register()} />
        </div>
        <div>
          <label htmlFor="city">City:</label>
          <input type="text" id="city" name="city" ref={register({ required: true })} />
          <span>{ errors.city && "City is required" }</span>
        </div>
        <div>
          <label htmlFor="state">State:</label>
          <input type="text" id="state" name="state" ref={register({ required: true })} />
          <span>{ errors.state && "State is required" }</span>
        </div>
        <div>
          <label htmlFor="zip">Zip:</label>
          <input type="text" id="zip" name="zip" ref={register({ required: true })} />
          <span>{ errors.zip && "Zip is required" }</span>
        </div>
        <div>
          <label htmlFor="telephone">Telephone:</label>
          <input type="text" id="telephone" name="telephone" ref={register({ required: true, maxLength: 11, minLength: 8 })} />
          <span>{ errors.telephone && "A proper telephone number is required" }</span>
        </div>
        <div>
          <label htmlFor="email">Email:</label>
          <input type="text" id="email" name="email" ref={register({ required: true, pattern: /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/ })} />
          <span>{ errors.email && "A proper email is required" }</span>
        </div>
        <div>
          <input type="submit" value="Register"></input>
        </div>
      </form>
    </div>
  )
}