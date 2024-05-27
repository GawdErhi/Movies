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
                    <img id="posterImgIdentifier" src="" />
                </div>
                <div className="col-md-8">
                    <div className="row pt-4">
                    <div className="col-12">
                            <p className="movie-detail-title">Plot</p>
                            <p className="movie-detail-content" id="plotIdentifier"></p>
                        </div>
                        <div className="row mx-0 px-0">
                            <div className="col-4">
                                <p className="movie-detail-title">Title</p>
                                <p className="movie-detail-content" id="titleIdentifier"></p>
                            </div>
                            <div className="col-4">
                                <p className="movie-detail-title">Year</p>
                                <p className="movie-detail-content" id="yearIdentifier"></p>
                            </div>
                            <div className="col-4">
                                <p className="movie-detail-title">Rated</p>
                                <p className="movie-detail-content" id="ratedIdentifier"></p>
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
                                <p className="movie-detail-content" id="imdbRatingIdentifier"></p>
                            </div>
                            <div className="col-4">
                                <p className="movie-detail-title">Box Office</p>
                                <p className="movie-detail-content" id="boxOfficeIdentifier"></p>
                            </div>
                            <div className="col-4">
                                <p className="movie-detail-title">Website</p>
                                <p className="movie-detail-content" id="websiteIdentifier"></p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}