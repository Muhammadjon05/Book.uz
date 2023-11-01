﻿namespace Book.uz.Exceptions;

public class CategoryNotFoundException : Exception
{
    public CategoryNotFoundException(Guid id) : base($"Category not found with id:{id}")
    {

    }
}