const express = require('express')
const bcrypt = require('bcrypt')
const User = require('../models/user')
const router = express.Router()

router.post('/', (req, res) => {
    User.findOne({ username: req.body.username }, (error, user) => {
        if (error) {
          res.status(500).send(error)
        } else if (!user) {
          res.status(404).send('User not found')
        } else {
            bcrypt.compare(req.body.password, user.password, (error, result) => {
                if (result) {
                res.status(200).send('Password is correct')
                } else {
                res.status(401).send('Password is incorrect')
                }
            })
        }
    })
})

module.exports = router