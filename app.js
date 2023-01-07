const express = require('express')
const mongoose = require('mongoose')
require('dotenv').config();
const app = express()

const uri = process.env.MONGO_URI
const registerRoute = require('./routes/register')
const loginRoute = require('./routes/login')

mongoose.set('strictQuery', false)

mongoose.connect(uri, { useNewUrlParser: true, useUnifiedTopology: true })
    .then(() => console.log('Connected to db'))
    .catch(err => console.log('Could not connect to MongoDB', err))

app.use(express.urlencoded({ extended: true }))
app.use(express.json());
app.use('/register', registerRoute)
app.use('/login', loginRoute)

app.listen(3000, () => console.log('Listening on port 3000'))