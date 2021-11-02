/*
 * Continous Food Delievery
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 1.0.0
 * 
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using Cfd.Attributes;
using Cfd.Models;

namespace Cfd.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class CartApiController : ControllerBase
    {
        private readonly CfdContext _context;

        public CartApiController(CfdContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add a menu item a cart
        /// </summary>
        /// <remarks>Creates a new item in the cart. Duplicates are allowed</remarks>
        /// <param name="menuItem">Item to add to the cart</param>
        /// <response code="201">Null response</response>
        /// <response code="0">unexpected error</response>
        [HttpPost]
        [Route("/CFD/1.0.0/cart")]
        [Consumes("application/json")]
        [ValidateModelState]
        [SwaggerOperation("AddCartItem")]
        [SwaggerResponse(statusCode: 0, type: typeof(Error), description: "unexpected error")]
        public virtual IActionResult AddCartItem([FromBody]MenuItem menuItem)
        {

            _context.CartItems.Add(menuItem);
            _context.SaveChanges();

            return CreatedAtAction("AddCartItem", menuItem);

        }

        /// <summary>
        /// Remove item from cart
        /// </summary>
        /// <remarks>The item must be in the cart. If multiple of same item, call this twice </remarks>
        /// <param name="itemId">The menu item to delete from cart</param>
        /// <response code="201">Null response</response>
        /// <response code="0">unexpected error</response>
        [HttpDelete]
        [Route("/CFD/1.0.0/cart/{itemId}")]
        [ValidateModelState]
        [SwaggerOperation("DeleteCartItem")]
        [SwaggerResponse(statusCode: 0, type: typeof(Error), description: "unexpected error")]
        public virtual IActionResult DeleteCartItem([FromRoute (Name = "itemId")][Required]int itemId)
        {
            MenuItem menuitem = null;

           foreach (var item in _context.CartItems)
            {
                if (item.Id == itemId)
                {
                    menuitem = item;
                    _context.CartItems.Remove(item);
                    _context.SaveChanges();
                }
            }

            return CreatedAtAction("DeleteCartItem", new { id = menuitem.Id}, menuitem);

        }

        /// <summary>
        /// List all cart items
        /// </summary>
        /// <param name="limit">How many items to return at one time (max 100)</param>
        /// <response code="200">A paged array of cart items</response>
        /// <response code="0">unexpected error</response>
        [HttpGet]
        [Route("/CFD/1.0.0/cart")]
        [ValidateModelState]
        [SwaggerOperation("ListCart")]
        [SwaggerResponse(statusCode: 200, type: typeof(Cart), description: "A paged array of cart items")]
        [SwaggerResponse(statusCode: 0, type: typeof(Error), description: "unexpected error")]
        public virtual IActionResult ListCart([FromQuery (Name = "limit")]int? limit)
        {
            List<MenuItem> CartList = new List<MenuItem>();
            foreach (var item in _context.CartItems)
            {
                CartList.Add(item);
            }

            return CreatedAtAction("ListCart", new { CartList });


        }
    }
}