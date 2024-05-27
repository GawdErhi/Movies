import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import './MovieDetailSection.css';
import { useLocation } from 'react-router-dom';
import axios from 'axios';

export default function MovieDetailSection(props){

    const params = new URLSearchParams(location.search);
    const param1 = params.get('param1');
    
    axios.get(`https://localhost:7052/Movies/details/${param1}`).then(res => {
            if(!res.data.data.response){
                alert(res.data.data.error);
            }else{
                
                document.querySelector("#plotIdentifier").innerHTML = res.data.data.plot;
                document.querySelector("#titleIdentifier").innerHTML = res.data.data.title;
                document.querySelector("#yearIdentifier").innerHTML = res.data.data.year;
                document.querySelector("#ratedIdentifier").innerHTML = res.data.data.rated;
                document.querySelector("#imdbRatingIdentifier").innerHTML = res.data.data.imdbRating;
                document.querySelector("#boxOfficeIdentifier").innerHTML = res.data.data.boxOffice;
                document.querySelector("#websiteIdentifier").innerHTML = res.data.data.website;
                document.querySelector("#imdbVotesIdentifier").innerHTML = res.data.data.imdbVotes;
                document.querySelector("#metascoreIdentifier").innerHTML = res.data.data.metascore;
                document.querySelector("#runtimeIdentifier").innerHTML = res.data.data.runtime;
                document.querySelector("#posterImgIdentifier").src = res.data.data.poster;

            }
        });

    return (
        <div>
            <div className="row mx-0">
                <div className="col-md-4">
                    <img id="posterImgIdentifier" src="https://m.media-amazon.com/images/M/MV5BOGE4NzU1YTAtNzA3Mi00ZTA2LTg2YmYtMDJmMThiMjlkYjg2XkEyXkFqcGdeQXVyNTgzMDMzMTg@._V1_SX300.jpg" />
                </div>
                <div className="col-md-8">
                    <div className="row pt-4">
                    <div className="col-12">
                            <p className="movie-detail-title">Plot</p>
                            <p className="movie-detail-content" id="plotIdentifier">The powerful but arrogant god Thor is cast out of Asgard to live amongst humans in Midgard (Earth), where he soon becomes one of their finest defenders.</p>
                        </div>
                        <div className="row mx-0 px-0">
                            <div className="col-4">
                                <p className="movie-detail-title">Title</p>
                                <p className="movie-detail-content" id="titleIdentifier">Thor</p>
                            </div>
                            <div className="col-4">
                                <p className="movie-detail-title">Year</p>
                                <p className="movie-detail-content" id="yearIdentifier">2011</p>
                            </div>
                            <div className="col-4">
                                <p className="movie-detail-title">Rated</p>
                                <p className="movie-detail-content" id="ratedIdentifier">PG-13</p>
                            </div>
                        </div>
                        <div className="row mx-0 px-0">
                            <div className="col-4">
                                <p className="movie-detail-title">Runtime</p>
                                <p className="movie-detail-content" id="runtimeIdentifier"></p>
                            </div>
                            <div className="col-4">
                                <p className="movie-detail-title">Metascore</p>
                                <p className="movie-detail-content" id="metascoreIdentifier"></p>
                            </div>
                            <div className="col-4">
                                <p className="movie-detail-title">IMDB Votes</p>
                                <p className="movie-detail-content" id="imdbVotesIdentifier"></p>
                            </div>
                        </div>
                        <div className="row mx-0 px-0">
                            <div className="col-4">
                                <p className="movie-detail-title">IMDB Rating</p>
                                <p className="movie-detail-content" id="imdbRatingIdentifier">7.0</p>
                            </div>
                            <div className="col-4">
                                <p className="movie-detail-title">Box Office</p>
                                <p className="movie-detail-content" id="boxOfficeIdentifier">$181,030,624</p>
                            </div>
                            <div className="col-4">
                                <p className="movie-detail-title">Website</p>
                                <p className="movie-detail-content" id="websiteIdentifier">N/A</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}