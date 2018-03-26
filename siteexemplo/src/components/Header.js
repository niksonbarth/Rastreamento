import React from 'react'
import { Link } from 'react-router-dom'

const Header = () => (
  <header>
    <nav>
      <ul>
        <li><Link to='/'>Home</Link></li>
        <li><Link to='/Price'>Preço</Link></li>
        <li><Link to='/contact'>Contato</Link></li>
        <li><Link to='/about'>Sobre</Link></li>
      </ul>
    </nav>
  </header>
)

export default Header