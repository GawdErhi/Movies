import { BrowserRouter as Router, Route, Switch, Link } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import './Layout.css';
import logo from './logo.svg';
import App from './App';
import SearchBar from './SearchBar';
import MovieDetailSection from './MovieDetailSection';

export default function Layout(props) {
    return (
        <Router>
            <div className="main-container">
                <div>
                    <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
                        <a class="navbar-brand mt-2 mt-lg-0" href="#">
                            <img
                                src={logo}
                                height="45"
                                alt="React Logo"
                            />
                        </a>
                    </nav>
                </div>
                <div className="body-container">
                    <Switch>
                        <Route path='/details'>
                            <MovieDetailSection />
                        </Route>
                        <Route path='/'>
                            <SearchBar />
                        </Route>
                    </Switch>
                </div>
                <div>
                    <footer className="bg-body-tertiary text-center text-lg-start">
                        <div className="text-center p-3">
                            © 2024 Copyright: <a className="text-body" href="https://www.linkedin.com/in/erhi-ogbudje-49985318b">Erhi Ogbudje</a>
                        </div>
                    </footer>
                </div>
            </div>
        </Router>
    );
}