import React from 'react'
import { Link } from 'react-router-dom'


const Header = () => (
  <header>
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top">
      <div class="container">
        <Link class="navbar-brand" to='/'>Site Exemplo</Link>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarResponsive">
          <ul class="navbar-nav ml-auto">
            <li class="nav-item">
              <Link class="nav-link" to='/'>Home</Link>
            </li>
            <li class="nav-item">
            <Link class="nav-link" to='/Price'>Preço</Link>
            </li>
            <li class="nav-item">
            <Link class="nav-link" to='/contact'>Contato</Link>
            </li>
            <li class="nav-item">
            <Link class="nav-link" to='/about'>Sobre</Link>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  </header>
)

export default Header