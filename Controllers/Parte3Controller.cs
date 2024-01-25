﻿using Microsoft.AspNetCore.Mvc;
using ProvaPub.Contracts.Services;
using ProvaPub.Entities;
using ProvaPub.Fixed;

namespace ProvaPub.Controllers;

/// <summary>
/// Esse teste simula um pagamento de uma compra.
/// O método PayOrder aceita diversas formas de pagamento. Dentro desse método é feita uma estrutura de diversos "if" para cada um deles.
/// Sabemos, no entanto, que esse formato não é adequado, em especial para futuras inclusões de formas de pagamento.
/// Como você reestruturaria o método PayOrder para que ele ficasse mais aderente com as boas práticas de arquitetura de sistemas?
/// </summary>
[ApiController]
[Route("[controller]")]
public class Parte3Controller :  ControllerBase
{
	private readonly IOrderService _orderService;
	public Parte3Controller(IOrderService orderService)
	{
		_orderService = orderService;
	}
	
	[HttpGet("orders")]
	public async Task<Order> PlaceOrder(PaymentMethod paymentMethod, decimal paymentValue, int customerId)
	{
		return await _orderService.PayOrder(paymentMethod, paymentValue, customerId);
	}
}