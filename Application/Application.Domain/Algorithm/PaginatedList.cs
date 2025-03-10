﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Domain.Algorithm
{
    public class PaginatedList<T> : List<T>
    {
        public List<T> Items { get; private set; }
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public int TotalItems { get; private set; }

        public PaginatedList(List<T> items, int pageIndex, int totalPages, int totalItems)
        {
            Items = items;
            PageIndex = pageIndex;
            TotalPages = totalPages;
            TotalItems = totalItems;
            AddRange(items);
        }

        public bool HasPreviousPage
        {
            get { return PageIndex > 1; }
        }

        public bool HasNextPage
        {
            get { return PageIndex < TotalPages; }
        }

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
