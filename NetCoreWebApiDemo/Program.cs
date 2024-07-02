using NetCoreWebApiDemo.Models;
using System;
using Oracle.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;
using NetCoreWebApiDemo.utils;
using log4net.Config;
using log4net;
using System.Reflection;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region ��Log4Net����Logging���򼯣�����ע�룩
//AddLog4Net�����еĲ����������ļ���·��
//�������ļ������ڸ�Ŀ¼�������������
builder.Logging.AddLog4Net("Config/log4net.config");
#endregion



var connectionString = builder.Configuration.GetConnectionString("ConStr");
builder.Services.AddDbContext<MyDBContext>(options =>
          options.UseOracle(connectionString));
builder.Services.AddSingleton<DbHelperOracle>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
