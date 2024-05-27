import 'bootstrap/dist/css/bootstrap.css';
import { BrowserRouter as Router, Route, Switch, Link, useHistory } from 'react-router-dom';
import React from 'react';
import './SearchBar.css';
import axios from 'axios';

export default function SearchBar(props){
    let targetPath = "details";
    const history = useHistory();

    const fetchResult = (event) => {
        console.log();
        let query = document.querySelector("#searchInput").value;
        axios.get(`https://localhost:7052/Movies/search/${query}`).then(res => {
            if(!res.data.data.response){
                alert(res.data.data.error);
            }else{
                document.querySelector("#moviePosterImg").src = res.data.data.poster;
                document.querySelector("#movieTitleText").innerHTML = res.data.data.title;
                document.querySelector("#movieRuntimeText").innerHTML = res.data.data.runtime;
                document.querySelector("#searchContent").style.display = "block";

                history.push(`/details?param1=${res.data.data.id}`);
            }
        });
    }

    return (<div>
        <div className="row px-0 mx-0 movie-search-bar-container">
            <h3>Search for Movies</h3>
            <div className="col-12 py-4">
                <div className="movie-search-bar-content">
                    <div className="search-bar-input">
                <div className="input-group mb-0">
                    <input type="text" className="form-control" id="searchInput" placeholder="movie, series, film title"/>
                    <div className="input-group-append">
                        <button className="btn btn-outline-secondary" type="button" onClick={fetchResult}>search</button>
                    </div>
                </div>
                <span className="custom-loader"></span>
                </div>
                <div className="search-content row" id="searchContent">
                    <Link to={targetPath}>
                    <div className="col-1">
                    <img id="moviePosterImg" src="https://m.media-amazon.com/images/M/MV5BOGE4NzU1YTAtNzA3Mi00ZTA2LTg2YmYtMDJmMThiMjlkYjg2XkEyXkFqcGdeQXVyNTgzMDMzMTg@._V1_SX300.jpg"/>
                    </div>
                    <div className="col-10">
                        <p><span className="movie-title-text" id="movieTitleText">Thor the dark world</span><br/><span className="movie-runtime-text" id="movieRuntimeText">Runtime 115 mins</span></p>
                    </div>
                    </Link>
                </div>
                </div>
            </div>
        </div>
    </div>
    );
}