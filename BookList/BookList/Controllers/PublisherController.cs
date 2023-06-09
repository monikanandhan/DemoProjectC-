﻿using BookList.Model.ModelView;
using BookList.service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        public PublisherService publisherservice;
        public PublisherController(PublisherService _publisherservice)
        {
            publisherservice = _publisherservice;
        }

        [HttpPost]
        public IActionResult AddPublisher(PublisherVM publisher)
        {
            publisherservice.AddPublisher(publisher);
            return Ok();
        }

        [HttpGet("{id}")]

        public IActionResult GetPublisher(int id)
        {
            var _response = publisherservice.GetPublisherByID(id);
            return Ok(_response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePublisher(int id)
        {
            publisherservice.DeletePublisherById(id);
            return Ok();
        }
    }
}
}
