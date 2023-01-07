const express = require('express')
const bcrypt = require('bcrypt')
const User = require('../models/user')
const router = express.Router()

router.post('/', (req, res) => {
    bcrypt.hash(req.body.password, 10, (error, hash) => {
        if (error) {
          res.status(500).send(error)
        } else {
          const user = new User({
            username: req.body.username,
            email: req.body.email,
            password: hash
          })
      
          user.save()
            .then('Successfully created a new user')
            .catch(error => { res.send(error) })
        }
    })
})

module.exports = router